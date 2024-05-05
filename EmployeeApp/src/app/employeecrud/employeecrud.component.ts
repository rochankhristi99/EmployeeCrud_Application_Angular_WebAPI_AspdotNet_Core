import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employeecrud',
  templateUrl: './employeecrud.component.html',
  styles: ''
})
export class EmployeecrudComponent implements OnInit {
  // Array to store employee data
  EmployeeArray: any[] = [];
  // Flag to indicate whether data is loaded
  isResultLoaded = false;
  // Flag to indicate if update form is active
  isUpdateFormActive = false;

  // Form fields
  firstname: string = ""; 
  lastname: string = "";
  email: string = "";
  mobileNo: string = "";

  // ID of the current employee being updated
  currentEmployeeID = "";

  constructor(private http: HttpClient) {
    // Call method to fetch all employees upon component initialization
    this.getAllEmployee();
  }

  ngOnInit(): void {
  }

  // Method to fetch all employees
  getAllEmployee() {
    this.http.get("https://localhost:7248/api/employee/index")
      .subscribe((resultData: any) => {
        this.isResultLoaded = true;
        console.log(resultData);
        this.EmployeeArray = resultData;
      });
  }

  // Method to register a new employee
  register() {
    let bodyData = {
      "firstname": this.firstname,
      "lastname": this.lastname,
      "email": this.email,
      "mobileNo": this.mobileNo
    };

    this.http.post("https://localhost:7248/api/employee/Create", bodyData).subscribe((resultData: any) => {
      console.log(resultData);
      alert("Employee Registered Successfully")
      this.getAllEmployee();
     // this.clearForm();
    window.location.reload(); // Reload the page
    });
  }

  // Method to set data for updating an employee
  setUpdate(data: any) {
    this.firstname = data.firstname;
    this.lastname = data.lastname;
    this.email = data.email;
    this.mobileNo = data.mobileNo;
    this.currentEmployeeID = data.empId;
    this.isUpdateFormActive = true;
  }

  // Method to update employee records
  UpdateRecords() {
    let bodyData = {
      "empId": this.currentEmployeeID,
      "firstname": this.firstname,
      "lastname": this.lastname,
      "email": this.email,
      "mobileNo": this.mobileNo
    };

    this.http.put("https://localhost:7248/api/employee/Edit", bodyData).subscribe((resultData: any) => {
      console.log(resultData);
      alert("Employee Registered Updated")
      this.getAllEmployee();
    });
  }

  // Method to save form data
  save(form: any) {
    if (form.valid) {
      this.registerOrUpdate();
    } else {
      alert("Please fill out all required fields correctly.");
    }
  }

  // Method to register or update employee based on current state
  registerOrUpdate() {
    if (this.currentEmployeeID === '') {
      this.register();
    } else {
      this.UpdateRecords();
    }
  }

  // Method to delete employee records
  setDelete(data: any) {
    let bodyData = {
      "empId": data.empId,
      "firstname": data.firstname,
      "lastname": data.lastname,
      "email": data.email,
      "mobileNo": data.mobileNo
    };

    this.http.post("https://localhost:7248/api/employee/delete", bodyData).subscribe((resultData: any) => {
      console.log(resultData);
      alert("Employee Deleted")
      this.getAllEmployee();
    });
  }

  // Method to clear form data
  clearForm() {
    this.firstname = '';
    this.lastname = '';
    this.email = '';
    this.mobileNo = '';
  }
}
