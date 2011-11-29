
// Overall viewmodel for this screen, along with initial state
function taskListViewModel() {

    var self = this;

    this.rows = ko.observableArray([]);
    this.game_won = ko.observable();
    this.game_lost = ko.observable();
    this.game_has_finished = ko.observable();

    this.reveal = function (tile) {

        $.post("Game/AjaxReveal", { col: tile.column, row: tile.row }, function (data) {

            self.update_mines();
        });
    };

    this.update_mines = function () {
        $.get("Game/Ajax", function (data) {

            var rows = $.map(data.tile_grid, function (item) {
                return new row($.map(item, function (tiles) {
                    return new tile(tiles.row, tiles.column, tiles.has_been_revealed, tiles.tile_image, self)
                }))
            })

            self.game_won(data.game_won);
            self.game_lost(data.game_lost);
            self.game_has_finished( data.game_won || data.game_lost);

            self.rows(rows)
        });
    };

    // Load initial state from server
    self.update_mines();
};

function row(tiles) {
    this.tiles = ko.observable(tiles);
}

function tile(row, column, has_been_revealed, tile_image, ownerViewModel) {
    this.row = ko.observable(row);
    this.column = ko.observable(column);
    this.has_been_revealed = has_been_revealed;
    this.tile_image = tile_image;

    this.reveal = function () {
        if (this.has_been_revealed != true) {
            ownerViewModel.reveal(this);
        }
    };
    this.ownerViewModel = ownerViewModel;
}