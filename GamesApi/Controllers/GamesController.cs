using GameApi.Data;
using GameApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase {
    [HttpGet]
    // Метод 1 — GET /api/games (получить все игры)
    public ActionResult<List<Game>> GetAll() {
        return Ok(GamesStore.Games);
    }
    // Метод 2 — GET /api/games/{id} (получить одну игру)
    [HttpGet("{id}")]
    public ActionResult<Game> GetById(int id) {
        var game = GamesStore.Games.FirstOrDefault(g => g.Id == id);
        if (game is null) {
            return NotFound(new { message = $"Игра с id={id} не найдена" });
        }
        return Ok(game);
    }
    // Метод 3 — POST /api/games (добавить игру)
    [HttpPost]
    public ActionResult<Game> Create([FromBody] Game game) {
        game.Id = GamesStore.NextId();
        GamesStore.Games.Add(game);
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
    }
    // Метод 4 — DELETE /api/games/{id} (удалить игру)
    [HttpDelete("{id}")]
    public ActionResult Delete(int id) {
        var game = GamesStore.Games.FirstOrDefault(g => g.Id == id);
        if (game is null) {
            return NotFound(new { message = $"Игра с id={id} не найдена" });
        }
        GamesStore.Games.Remove(game);
        return NoContent();
    }
    // Метод 5 — PUT /api/games/{id} (обновить игру)
    [HttpPut("{id}")]
    public ActionResult<Game> Update(int id, [FromBody] Game updated) {
        var game = GamesStore.Games.FirstOrDefault(g => g.Id == id);
        if (game is null) {
            return NotFound(new { message = $"Игра с id = {id} не найдена" });
        }
        game.Title = updated.Title;
        game.Genre = updated.Genre;
        game.ReleaseYear = updated.ReleaseYear;
        return Ok(game);
    }
}