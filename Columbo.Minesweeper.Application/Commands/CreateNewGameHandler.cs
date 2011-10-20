using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;
using log4net;
using System;

namespace Columbo.Minesweeper.Application.Commands
{
    public class CreateNewGameHandler : ICommandHandler<CreateGameCommand>
    {
        private IMinesweeperFactory _minesweeper_factory;
        private IGameRepository _game_repository;
        private IGameTypeMapper _game_options_mapper;

        public CreateNewGameHandler(IMinesweeperFactory minesweeper_factory,
                                    IGameRepository game_repository,
                                    IGameTypeMapper game_options_mapper)
        {
            _minesweeper_factory = minesweeper_factory;
            _game_repository = game_repository;
            _game_options_mapper = game_options_mapper;
        }

        public void handle(CreateGameCommand command)
        {            
            // validate command?
            try
            {
                var game_options = _game_options_mapper.map_from(command);

                var new_game_of_minesweeper = _minesweeper_factory.create_game_with(game_options);                
                
                _game_repository.add(new_game_of_minesweeper);
            }
            catch (Exception ex)
            {
                var _log = LogManager.GetLogger(typeof(CreateNewGameHandler));
                // test logging
                _log.Error(String.Format("{0}", command.ToString()));
            }            
        }
    }
}
