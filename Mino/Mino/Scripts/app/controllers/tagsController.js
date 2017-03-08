var TagsController = function (tagsService) {

    var getTagName = function () {
        return $(".js-tag-name").val();
    }

    var getTagId = function(tag) {
        return tag.attr("data-id");
    }

    var showForm = function () {
        $(".js-add-tag").addClass("animated bounceOutRight");
        $(".js-tag-form").removeClass("hidden").addClass("animated bounceInLeft");
    }

    var done = function () {
        location.reload();
    }

    var fail = function () {
        alert("Something failed!");
    }

    var createTag = function () {
        tagsService.create(getTagName(), done, fail);
    }

    var deleteTag = function (tag) {
        tagsService.delet(getTagId(tag), done, fail);
    }

    var init = function () {
        $(".js-show-tag-form").on("click", showForm);
        $(".js-create-tag").on("click", createTag);
        $(".js-delete-tag").on("click", function () { deleteTag($(this)) });
    }

    return {
        init: init
    }
}(TagsService);