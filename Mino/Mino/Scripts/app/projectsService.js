var ProjectsService = function () {

    var create = function (name, color, done, fail) {
        $.post("/api/projects/create", { name: name, color: color })
               .done(done)
               .fail(fail);
    }

    return {
        create: create
    }
}();