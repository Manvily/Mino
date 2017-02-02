var TagsController = function (tagService) {

    var getTagName = function () {
        return $(".js-tag-name").val();
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
        tagService.create(getTagName(), done, fail);
    }

    var init = function () {
        $(".js-show-tag-form").on("click", showForm);
        $(".js-create-tag").on("click", createTag);
    }

    return {
        init: init
    }
}(TagsService);