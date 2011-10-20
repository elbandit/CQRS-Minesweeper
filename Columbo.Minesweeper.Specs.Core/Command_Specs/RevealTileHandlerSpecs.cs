using System;
using Columbo.Minesweeper.Application.Commands;
using Columbo.Minesweeper.Application.Domain;
using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;

namespace Columbo.Minesweeper.Specs.Core.Command_Specs
{
    public class RevealTileHandlerSpecs
    {
        [Subject(typeof(RevealTileHandler))]
        public class when_handling_a_reveal_a_tile_command : WithSubject<RevealTileHandler>
        {
            private Establish context = () =>
            {
                reveal_tile_command = new RevealTileCommand();
                reveal_tile_command.coordinate = Coordinate.parse("1,1");
                game = The<IMinesweeper>();

                The<IGameRepository>().WhenToldTo(x => x.get_by(reveal_tile_command.player_id)).Return(game);
            };

            private Because of = () => Subject.handle(reveal_tile_command);

            private It should_retrive_the_game_from_the_game_center = () =>
            {
                The<IGameRepository>().WasToldTo(x => x.get_by(reveal_tile_command.player_id));
            };

            private It should_tell_the_game_to_reveal_a_tile = () =>
            {
                game.WasToldTo(x => x.reveal_tile_at(Arg<Coordinate>.Matches(c => c.Equals(reveal_tile_command.coordinate))));
            };

            private static RevealTileCommand reveal_tile_command;
            private static IMinesweeper game;
        }
    }
}
