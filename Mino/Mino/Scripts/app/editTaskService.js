
var EditTaskService = function () {

    var edit = function (taskId, done, fail) {
        $.post("/api/tasks/edit",
                      {
                          name: $(".js-edit-task-name").val(),
                          taskId: taskId,
                          projectId: $(".js-edit-dropdown-projects").val(),
                          tagId: $(".js-edit-dropdown-tags").val(),
                          date: $(".js-edit-date").val(),
                          time: $(".js-edit-time").val(),
                          priority: $(".js-edit-dropdown-priority").val()
                      })
                      .done(done)
                      .fail(fail);
    }

    var delet = function (taskId, done, fail) {
        $.ajax({
            url: "/api/tasks/delete",
            method: "DELETE",
            data: "taskId=" + taskId
        })
        .done(done)
        .fail(fail);
    }

    var finish = function(taskId, done, fail) {
        $.post("/api/tasks/finish", { taskId: taskId })
            .done(done)
            .fail(fail);
    }

    return {
        edit: edit,
        delet: delet,
        finish: finish
    }
}();

