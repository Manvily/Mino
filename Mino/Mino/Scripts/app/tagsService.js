var TagsService = function () {

    var create = function (name, done, fail) {
        $.post("/api/tags/create", { name: name })
                    .done(done)
                    .fail(fail);
    }

    var delet = function (id, done, fail) {
        $.ajax({
            method: "DELETE",
            url: "/api/tags/",
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