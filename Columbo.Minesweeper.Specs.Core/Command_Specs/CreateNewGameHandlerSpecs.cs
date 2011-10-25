using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Commands;
using Columbo.Minesweeper.Application.Commands.Infrastructure;
using Columbo.Minesweeper.Application.Domain;
using Machine.Specifications;
using Machine.Fakes;
using NUnit.Framework;

namespace Columbo.Minesweeper.Specs.Core.Command_Specs
{    
    public class CreateNewGameHandlerSpecs
    {
        [Subject(typeof(CreateGameHandler))]
        public class when_handling_a_create_new_game_command : WithSubject<CreateGameHandler>
        {
            private Establish context = () =>
            {
                create_game_command = new CreateGameCommand();
                create_game_command.game_difficulty = new GameDifficulty(3, 3, 1);
                create_game_command.player_id = Guid.NewGuid();
                
                The<IGameTypeMapper>().WhenToldTo(x => x.map_from(create_game_command)).Return(game_options);

                minesweeper = An<IMinesweeper>();

                The<IMinesweeperFactory>().WhenToldTo(x => x.create_game_with(game_options)).Return(minesweeper);
            };

            private Because of = () => Subject.handle(create_game_command);

            private It should_check_if_the_command_is_valid = () =>
            {
                Assert.Fail();
            };

            private It should_create_a_new_game = () =>
            {
                The<IMinesweeperFactory>().WasToldTo(x => x.create_game_with(game_options));
            };

            private It should_convert_the_command_to_a_game_type = () =>
            {
                The<IGameTypeMapper>().WasToldTo(x => x.map_from(create_game_command));
            };
            
            private It should_add_the_new_game_to_the_repository = () =>
            {
                The<IGameRepository>().WasToldTo(x => x.add(minesweeper));
            };

            private static CreateGameCommand create_game_command;
            private static IMinesweeper minesweeper;            
            private static GameOptions game_options;
        }
    }    
}
