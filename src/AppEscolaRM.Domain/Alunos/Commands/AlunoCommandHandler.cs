
namespace AppEscolaRM.Domain.Alunos.Commands
{
    using Alunos.Repository;
    using AppEscolaRM.Domain.Alunos.Events;
    using CommandHandlers;
    using Core.Bus;
    using Core.Events;
    using Core.Notifications;
    using Interfaces;
    using System;

    public class AlunoCommandHandler : 
        CommandHandler,
        IHandler<RegistrarAlunoCommand>,
        IHandler<AtualizarAlunoCommand>,
        IHandler<ExcluirAlunoCommand>
    {

        private readonly IAlunoRepository _alunoRepository;
        private readonly IValidadorCpfRepository _validadorCpfRepository;
        private readonly IBus _bus;

        public AlunoCommandHandler(
            IAlunoRepository alunoRepository,
            IUnitOfWork uow,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications
            ) : base(uow, bus, notifications)
        {
            _alunoRepository = alunoRepository;
            _bus = bus;
        }

        public void Handle(RegistrarAlunoCommand message)
        {
            var aluno = Aluno.AlunoFactory.NovoAlunoCompleto(message.Id, message.Nome, message.Cpf);

            if (!AlunoValido(aluno, message.MessageType)) return;
            
            _alunoRepository.Adicionar(aluno);

            if (Commit())
            {
                _bus.RaiseEvent(new AlunoRegistradoEvent(aluno.Id, aluno.Nome, aluno.Cpf));
            }
        }

        public void Handle(AtualizarAlunoCommand message)
        {
            var alunoAtual = _alunoRepository.ObterPorId(message.Id);

            if (!AlunoExistente(message.Id, message.MessageType)) return;

            var aluno = Aluno.AlunoFactory.NovoAlunoCompleto(message.Id, message.Nome, message.Cpf);

            if (!AlunoValido(aluno, message.MessageType)) return;

            _alunoRepository.Atualizar(aluno);

            if (Commit())
            {
                _bus.RaiseEvent(new AlunoAtualizadoEvent(aluno.Id, aluno.Nome, aluno.Cpf));
            }
        }

        public void Handle(ExcluirAlunoCommand message)
        {
            if (!AlunoExistente(message.Id, message.MessageType)) return;
            
            _alunoRepository.Remover(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new AlunoExcluidoEvent(message.Id));
            }           
        }

        private bool AlunoValido(Aluno aluno, string messageType)
        {
            if (aluno.EhValido())
            {
                var cpfValido = _validadorCpfRepository.ValidarCPF(aluno.Cpf);
                if (!cpfValido)
                {
                    _bus.RaiseEvent(new DomainNotification(messageType, "CPF Inválido."));
                    return false;
                }
                return true;
            }                

            NotificarValidacoesErro(aluno.ValidationResult);
            return false;
        }        

        private bool AlunoExistente(Guid id, string messageType)
        {
            var aluno = _alunoRepository.ObterPorId(id);

            if (aluno != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Aluno não encontrado."));
            return false;
        }

        
    }
}
