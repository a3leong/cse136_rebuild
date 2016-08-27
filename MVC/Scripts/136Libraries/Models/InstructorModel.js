function InstructorModel() {

    this.Load = function (callback) {
        /**      $.ajax({
                  url: "http://localhost:9393/Api/Instructor/GetInstructor",
                  data: "",
                  dataType: "json",
                  success: function (instructorData) {
                      callback(instructorData);
                  },
                  error: function () {
                      alert('Error while loading instructors.  Is your service layer running?');
                  }
              });  We do this for part 5 **/
        var Instructor = [];
        Instructor.push({
           first_name: "Gary",
            last_name: "Gillispie",
            title: "Professor"
        });
        Instructor.push({
            first_name: "Richard",
            last_name: "Ord",
            title: "Maestro"
        });
        callback(Instructor);
    };
}
