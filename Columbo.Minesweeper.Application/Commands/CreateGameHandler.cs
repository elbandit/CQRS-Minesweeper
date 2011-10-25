using Columbo.Minesweeper.Application.Commands.Infrastructure;
using Columbo.Minesweeper.Application.Domain;
using log4net;
using System;

namespace Columbo.Minesweeper.Application.Commands
{
    public class CreateGameHandler : ICommandHandler<CreateGameCommand>
    {
        private IMinesweeperFactory _minesweeper_factory;
        private IGameRepository _game_repository;
        private IGameTypeMapper _game_options_mapper;
        private IBus _bus;

        public CreateGameHandler(IMinesweeperFactory minesweeper_factory,
                                 IGameRepository game_repository,
                                 IGameTypeMapper game_options_mapper,
                                 IBus bus)
        {
            _minesweeper_factory = minesweeper_factory;
            _game_repository = game_repository;
            _game_options_mapper = game_options_mapper;
            _bus = bus;
        }

        public void handle(CreateGameCommand command)
        {                                    
            // validate command?

            try {
                finish_any_exisiting_game_for(command.player_id);

                start_new_game_for(command);
            }
            catch (Exception ex) {
                log(command, ex);
            }            
        }

        private void log(CreateGameCommand command, Exception ex)
        {
            var _log = LogManager.GetLogger(typeof(CreateGameHandler));            
            _log.Error(String.Format("{0}", command.ToString()));
        }

        private void start_new_game_for(CreateGameCommand command)
        {
            var game_options = _game_options_mapper.map_from(command);

            var new_game_of_minesweeper = _minesweeper_factory.create_game_with(game_options);                
                
            _game_repository.add(new_game_of_minesweeper);
        }

        private void finish_any_exisiting_game_for(Guid player_id)
        {
            _bus.send(new FinishGameCommand() { player_id = player_id });
        }
    }
}
