var AddTaskService = function () {

    var create = function (name, done, fail) {
        $.ajax({
            url: "/api/tasks/",
            method: "PUT",
            data: "name=" + name
        })
            .done(done)
            .fail(fail);
    }

    return {
        create: create
    }
}();