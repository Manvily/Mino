var AddTaskService = function () {

    var create = function (name, done, fail) {
        $.post("/api/tasks/create", {name: name})
            .done(done)
            .fail(fail);
    }

    return {
        create: create
    }
}();