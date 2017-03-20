var ProjectsService = function () {

    var create = function (name, color, done, fail) {
        $.post("/api/projects/create", { name: name, color: color })
               .done(done)
               .fail(fail);
    }

    var delet = function (id, done, fail) {
        //$.post("/api/projects/delete", { id: id})
        $.ajax({
            method: "DELETE",
            url: "/api/projects/delete",
            data: "id=" + id
        })
            .done(done)
            .fail(fail);
    }

    return {
        create: create,
        delet: delet
    }
}();