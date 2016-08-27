function StaffViewModel() {
    this.Load = function () {
        var StaffModelObj = new StaffModel();

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        StaffModelObj.Load(function (StaffData) {

            // courseList - presentation layer model retrieved from /Staff/GetStaff route.
            // StaffViewModel - view model for the html content
            var StaffViewModel = new Array();

            // DTO from the JSON model to the view model. In this case, StaffViewModel doesn't need the "id" attribute
            for (var i = 0; i < StaffData.length; i++) {
                StaffViewModel[i] = {
                    id: StaffData[i].id,
                    email: StaffData[i].email
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: StaffViewModel }, document.getElementById("divEditStaff"));
        });
    };
}
