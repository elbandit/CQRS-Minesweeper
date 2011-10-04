using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Commands;
using Columbo.Minesweeper.Application.Domain;
using Machine.Specifications;
using Machine.Fakes;
using NUnit.Framework;

namespace Columbo.Minesweeper.Specs.Core.Domain_Specs
{    
    public class when_handling_a_create_new_game_command : WithSubject<CreateNewGameHandler>
    {
        private Establish context = () =>
        {
            create_game_command = new CreateGameCommand();
            create_game_command.player_id = Guid.NewGuid();
        };

        private Because of = () => Subject.handle(create_game_command);

        private It should_check_if_the_command_is_valid = () =>
        {
            Assert.Fail();
        };

        private It should_add_a_new_Minesweeper_game_to_the_games_center = () =>
        {
            The<IGameCenter>().WasToldTo(x => x.start_a_new_game_for(create_game_command.player_id));
        };

        private static CreateGameCommand create_game_command;
    }
}
