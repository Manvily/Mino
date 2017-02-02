var TagsService = function () {

    var create = function (name, done, fail) {
        $.post("/api/tags/create", { name: name })
                    .done(done)
                    .fail(fail);
    }

    return {
        create: create
    }
}();