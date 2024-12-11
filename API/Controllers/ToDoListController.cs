using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using SQLitePCL;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListController : ControllerBase
{

    private readonly ILogger<ToDoListController> _logger;

    private readonly DataContext _context;

    public ToDoListController(ILogger<ToDoListController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// GET api/todolist
    /// </summary>
    /// <returns> A list of todolist</returns>
    [HttpGet(Name = "GetToDoList")]
    public ActionResult<List<Todo>> Get()
    {
        return this._context.ToDoList.ToList();
    }

    ///<summary>
    ///Get api/todolist/[id]
    ///</summary>
    ///<param name="id">todo id</param>
    ///<returns>A single todo</returns>
    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<Todo> GetById(Guid id)
    {
        var todo = this._context.ToDoList.Find(id);
        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    /// <summary>
    /// POST api/todolist
    /// </summary>
    /// <param name="request">JSON request containing todo fields</param>
    /// <return>A new todo</return>
    [HttpPost(Name = "Create")]
    public ActionResult<Todo> Create([FromBody] Todo request)
    {
        var todo = new Todo
        {
            Id = request.Id,
            Task = request.Task,
            Date = request.Date
        };

        _context.ToDoList.Add(todo);
        var success = _context.SaveChanges() > 0;

        if (success)
        {
            return Ok(todo);
        }

        throw new Exception("Error creating post");
    }

    /// <summary>
    /// PUT api/todo
    /// </summary>
    /// <param name="request">JSON request containing one or more updated todo fields</param>
    /// <returns>An updated todo</returns>
    [HttpPut(Name = "Update")]
    public ActionResult<Todo> Update([FromBody] Todo request)
    {
        //Find the existing post to update
        var todo = _context.ToDoList.Find(request.Id);
        if (todo == null)
        {
            throw new Exception("Could not find task");
        }

        //Update the post porperties with request values, if present
        todo.Task = request.Task != null ? request.Task : todo.Task;
        todo.Date = request.Date != DateTime.MinValue ? request.Date : todo.Date;

        var success = _context.SaveChanges() > 0;
        if (success)
        {
            return Ok(todo);
        }

        throw new Exception("Error updating task");
    }

}