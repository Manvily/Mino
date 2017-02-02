var ProjectsController = function (projectsService) {

    var getProjectName = function () {
        return $(".js-project-name").val();
    }

    var getProjectColor = function () {
        return $(".js-project-color").val();
    }

    var done = function () {
        location.reload();
    }

    var fail = function () {
        alert("Something failed!");
    }

    var showForm = function () {
        $(".js-add-project").addClass("animated bounceOutRight");
        $(".js-project-form").removeClass("hidden").addClass("animated bounceInLeft");
    }

    var createProject = function () {
        projectsService.create(getProjectName(), getProjectColor(), done, fail);
    }

    var init = function () {
        $(".js-show-project-form").on("click", showForm);
        $(".js-create-project").on("click", createProject);
    }

    return {
        init: init
    }
}(ProjectsService);