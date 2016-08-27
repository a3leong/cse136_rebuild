function StaffModel() {

    this.Load = function (callback) {
        /**      $.ajax({
                  url: "http://localhost:9393/Api/Staff/GetStaff",
                  data: "",
                  dataType: "json",
                  success: function (StaffData) {
                      callback(StaffData);
                  },
                  error: function () {
                      alert('Error while loading Staffs.  Is your service layer running?');
                  }
              });  We do this for part 5 **/
        var Staff = [];
        Staff.push({
            id: 1,
            email: "ggillispie@ucsd.edu",
        });
        Staff.push({
            id: 1,
            email: "something@something.com",
        });
        callback(Staff);
    };
}
