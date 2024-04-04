// ------------------------- global variable
var currentSelectedRow;         // holds which row is currently selected
let allRowsData = new Array();  // will store all the trainee data
let allFilterBox = document.querySelectorAll('.textSearchBox'); // hold all element of filter textboxes
let filterBoxesInputs = ["", "", "", "", "", "", "", "", "", ""];  // filter boxes input
let allFilterClearBtn = document.querySelectorAll('.close_btn'); // all elements of clear filter buttons
let sortingOrder = [undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined]; // storing the sorting orders for rendering the data, true for ascending order, and false for descending order, we have total

// ------------------------- signin box popup
document.getElementById('signInBtn').addEventListener('click', function () {
    $.ajax({
        url: "/Home/SignInPage",
        type: "GET",
        success: function (data) {
            document.getElementById('modalContainer').classList.remove('noDisplay');
            $("#registrationContainer").html(data);
        },
        error: function (xhr, status, error) {
            console.error("Error loading registration content:", error);
        }
    });
})

// ------------------------- registeration box popup
function GetRegisterationForm() {
    $.ajax({
        url: "/Home/RegisterationPage",
        type: "GET",
        success: function (data) {
            $("#registrationContainer").html(data);
        },
        error: function (error) {
            console.error("Error loading registration content:", error);
        }
    });
}

// ------------------------- Getting all rows
function GetAllRows() {
    $.ajax({
        url: "Home/GetAllTrainee",
        type: "GET",
        success: function (data) {
            RenderRowData(data);
        },
        error: function (error) {
            console.error("Error loading registration content:", error);
        }
    })
}

// ------------------------- Trainee class
class Trainee {
    constructor(serialNumber, prefix, firstName, middleName, lastName, education, joiningDate, currentAddress, currentCompany, dateOfBirth) {
        this.serialNumber = serialNumber;
        this.prefix = prefix;
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.education = education;
        this.joiningDate = joiningDate;
        this.currentAddress = currentAddress;
        this.currentCompany = currentCompany;
        this.dateOfBirth = dateOfBirth;
    }
}

// ------------------------- function to sort the trainee data
function SortData(data) {
    // ---- serial number
    if (sortingOrder[0]) {
        data = data.sort((a, b) => { return a.serialNumber - b.serialNumber; })
    }
    else if (sortingOrder[0] == false) {
        data = data.sort((a, b) => { return b.serialNumber - a.serialNumber; })
    }
    // ---- prefix
    if (sortingOrder[1]) {
        data = data.sort((a, b) => {
            return a.prefix.localeCompare(b.prefix, undefined, { sensitivity: 'accent' });
        });
    }
    else if (sortingOrder[1] == false) {
        data = data.sort((a, b) => {
            return b.prefix.localeCompare(a.prefix, undefined, { sensitivity: 'accent' });
        });
    }
    // ---- first name
    if (sortingOrder[2]) {
        data = data.sort((a, b) => {
            return a.firstName.localeCompare(b.firstName, undefined, { sensitivity: 'accent' });
        });
    }
    else if (sortingOrder[2] == false) {
        data = data.sort((a, b) => {
            return b.firstName.localeCompare(a.firstName, undefined, { sensitivity: 'accent' });
        });
    }
    // ---- middle name
    if (sortingOrder[3]) {
        data = data.sort((a, b) => {
            return a.middleName.localeCompare(b.middleName, undefined, { sensitivity: 'accent' });
        });
    }
    else if (sortingOrder[3] == false) {
        data = data.sort((a, b) => {
            return b.middleName.localeCompare(a.middleName, undefined, { sensitivity: 'accent' });
        });
    }
    // ---- last name
    if (sortingOrder[4]) {
        data = data.sort((a, b) => {
            return a.lastName.localeCompare(b.lastName, undefined, { sensitivity: 'accent' });
        });
    }
    else if (sortingOrder[4] == false) {
        data = data.sort((a, b) => {
            return b.lastName.localeCompare(a.lastName, undefined, { sensitivity: 'accent' });
        });
    }
    // ---- education
    if (sortingOrder[5]) {
        data = data.sort((a, b) => {
            return a.education.localeCompare(b.education, undefined, { sensitivity: 'accent' });
        });
    }
    else if (sortingOrder[5] == false) {
        data = data.sort((a, b) => {
            return b.education.localeCompare(a.education, undefined, { sensitivity: 'accent' });
        });
    }
    // ---- joining date
    if (sortingOrder[6]) {
        data = data.sort((a, b) => {
            return a.joiningDate.localeCompare(b.joiningDate, undefined, { sensitivity: 'accent' });
        });
    }
    else if (sortingOrder[6] == false) {
        data = data.sort((a, b) => {
            return b.joiningDate.localeCompare(a.joiningDate, undefined, { sensitivity: 'accent' });
        });
    }
    // ---- current address
    if (sortingOrder[7]) {
        data = data.sort((a, b) => {
            return a.currentAddress.localeCompare(b.currentAddress, undefined, { sensitivity: 'accent' });
        });
    }
    else if (sortingOrder[7] == false) {
        data = data.sort((a, b) => {
            return b.currentAddress.localeCompare(a.currentAddress, undefined, { sensitivity: 'accent' });
        });
    }
    // ---- current company
    if (sortingOrder[8]) {
        data = data.sort((a, b) => {
            return a.currentCompany.localeCompare(b.currentCompany, undefined, { sensitivity: 'accent' });
        });
    }
    else if (sortingOrder[8] == false) {
        data = data.sort((a, b) => {
            return b.currentCompany.localeCompare(a.currentCompany, undefined, { sensitivity: 'accent' });
        });
    }
    // ---- date of birth
    if (sortingOrder[9]) {
        data = data.sort((a, b) => {
            return a.dateOfBirth.localeCompare(b.dateOfBirth, undefined, { sensitivity: 'accent' });
        });
    }
    else if (sortingOrder[9] == false) {
        data = data.sort((a, b) => {
            return b.dateOfBirth.localeCompare(a.dateOfBirth, undefined, { sensitivity: 'accent' });
        });
    }
    return data;
}

// ------------------------- function to assign all trainee data as a list of Trainee Object
function assignTraineeData(data) {
    for (let trainee of data) {
        allRowsData.push(
            new Trainee(
                trainee.serialNumber,
                trainee.prefix,
                trainee.firstName,
                trainee.middleName,
                trainee.lastName,
                trainee.education.long_name,
                trainee.joiningDate,
                trainee.currentAddress,
                trainee.currentCompany,
                trainee.dateOfBirth
            )
        );
    }
}

// ------------------------- function to print all Trainee data to the table
function RenderRowData(dataToPrint = allRowsData) {
    if (document.querySelector('#traineeDataTable').classList.contains('noDisplay')) {
        document.querySelector('#traineeDataTable').classList.remove('noDisplay');
    }
    let tableRootElement = document.querySelector("#traineeDataTable tbody");
    const trElements = tableRootElement.querySelectorAll('tr');
    for (let elem = 1; elem < trElements.length; elem++) {
        trElements[elem].remove();
    }
    for (var singleRow of dataToPrint) {
        let newRow = document.createElement("tr");

        let pointerCell = document.createElement("td");
        newRow.appendChild(pointerCell);

        let serialNumberCell = document.createElement("td");
        serialNumberCell.textContent = singleRow.serialNumber + ".";
        newRow.appendChild(serialNumberCell);

        let prefixCell = document.createElement("td");
        prefixCell.textContent = singleRow.prefix;
        newRow.appendChild(prefixCell);

        let firstNameCell = document.createElement("td");
        firstNameCell.textContent = singleRow.firstName;
        newRow.appendChild(firstNameCell);

        let middleNameCell = document.createElement("td");
        middleNameCell.textContent = singleRow.middleName;
        newRow.appendChild(middleNameCell);

        let lastNameCell = document.createElement("td");
        lastNameCell.textContent = singleRow.lastName;
        newRow.appendChild(lastNameCell);

        let educationCell = document.createElement("td");
        educationCell.textContent = singleRow.education;
        newRow.appendChild(educationCell);

        let joiningDateCell = document.createElement("td");
        joiningDateCell.textContent = singleRow.joiningDate.split('T')[0];
        newRow.appendChild(joiningDateCell);

        let currentAddressCell = document.createElement("td");
        currentAddressCell.textContent = singleRow.currentAddress;
        newRow.appendChild(currentAddressCell);

        let currentCompanyCell = document.createElement("td");
        currentCompanyCell.textContent = singleRow.currentCompany;
        newRow.appendChild(currentCompanyCell);

        let dateOfBirthCell = document.createElement("td");
        dateOfBirthCell.textContent = singleRow.dateOfBirth.split('T')[0];
        newRow.appendChild(dateOfBirthCell);

        tableRootElement.appendChild(newRow);
    }

    // adding empty row in the end
    let newRow = document.createElement("tr");
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    newRow.appendChild(document.createElement("td"));
    tableRootElement.appendChild(newRow);
    RowPointerSelection();
}

// ------------------------- adding click functionality to the row pointer for selecting the row
function RowPointerSelection() {
    var allRows = document.querySelectorAll('#traineeDataTable tbody tr');
    for (let row = 1; row < allRows.length; row++) {
        allRows[row].querySelector('td').addEventListener("click", function () {
            // ----- clear previous selected row background
            ClearSelection(allRows);
            // ----- adding color to currently selected row 
            allRows[row].style.backgroundColor = "#F7EEDD";
            currentSelectedRow = row;
            // ----- enable / disable the nav buttons (add, edit, delete) on the basis of selected rows
            ToggleNavMenuBtns();
        });
        // ----- readonly view when any row pointer is double clicked
        allRows[row].querySelector('td').addEventListener('dblclick', function () {
            ReadOnlyViewTrainee();
        });
    }
}

// ------------------------- function to find the Id of the trainee of the current selected row 
function IdOfCurrentSelectedRow() {
    if (currentSelectedRow === undefined) {
        return 0;
    }
    let value = document.querySelectorAll('#traineeDataTable tbody tr')[currentSelectedRow].querySelectorAll('td')[1].innerText.split('.')[0];
    return value;
}

// ----------------------- clearing the bg of rows so that new row can be selected
function ClearSelection(allRows) {
    for (let row = 1; row < allRows.length; row++) {
        allRows[row].style.backgroundColor = "white";
    }
}

// ----------------------- funtion to delete 
function deleteSelected() {
    let userChoice = confirm("Are you sure to delete, it can't be reverted back");
    if (userChoice) {
        $.ajax({
            url: "Home/Delete/" + IdOfCurrentSelectedRow(),
            type: "GET",
            success: function (response) {
                GetAllRows();
                currentSelectedRow = undefined;
                document.getElementById('newBtn').classList.remove('disableBtn');
                document.getElementById('newBtn').classList.add('activeBtn');
                document.getElementById('editBtn').classList.remove('activeBtn');
                document.getElementById('editBtn').classList.add('disableBtn');
                document.getElementById('deleteBtn').classList.remove('activeBtn');
                document.getElementById('deleteBtn').classList.add('disableBtn');
            },
            error: function (xhr, status, error) {
                alert("Error: " + xhr.responseText);
            }
        })
    }
    else {
        // will do nothing
    }
}

// ----------------------- getting readOnly view for the selected trainee row
function ReadOnlyViewTrainee() {
    $.ajax({
        url: "Home/ReadOnlyView/" + IdOfCurrentSelectedRow(),
        type: "GET",
        success: function (data) {
            document.getElementById("modalContainer").style.display = "block";
            $("#modalContainer").html(data);
        },
        error: function (error) {
            console.error("Error loading registration content:", error);
        }
    })
}
// ----------------------- getting insert view or update view for selected row
function GetTraineeData() {
    $.ajax({
        url: "Home/Upsert/" + IdOfCurrentSelectedRow(),
        type: "GET",
        success: function (data) {
            document.getElementById("modalContainer").style.display = "block";
            $("#modalContainer").html(data);
        },
        error: function (error) {
            console.error("Error loading registration content:", error);
        }
    })
}

// ----------------------- filtering the trainee data based on the filter textboxes content
function findFilters(data) {
    // --------------- filtering serial number
    if (filterBoxesInputs[0].length != 0) {
        data = data.filter(trainee => {
            return trainee.serialNumber.toString().includes(filterBoxesInputs[0]);
        });
    }
    // --------------- filtering the prefix
    if (filterBoxesInputs[1].length != 0) {
        data = data.filter(trainee => {
            return trainee.prefix.toLowerCase().includes(filterBoxesInputs[1].toLowerCase());
        });
    }

    // --------------- filtering the firstName
    if (filterBoxesInputs[2].length != 0) {
        data = data.filter(trainee => {
            return trainee.firstName.toLowerCase().includes(filterBoxesInputs[2].toLowerCase());
        });
    }
    // --------------- filtering the middleName
    if (filterBoxesInputs[3].length != 0) {
        data = data.filter(trainee => {
            return trainee.middleName.toLowerCase().includes(filterBoxesInputs[3].toLowerCase());
        });
    }
    // --------------- filtering the lastName
    if (filterBoxesInputs[4].length != 0) {
        data = data.filter(trainee => {
            return trainee.lastName.toLowerCase().includes(filterBoxesInputs[4].toLowerCase());
        });
    }
    // --------------- filtering the education
    if (filterBoxesInputs[5].length != 0) {
        data = data.filter(trainee => {
            return trainee.education.toLowerCase().includes(filterBoxesInputs[5].toLowerCase());
        });
    }
    // --------------- filtering the joiningDate
    if (filterBoxesInputs[6].length != 0) {
        data = data.filter(trainee => {
            return trainee.joiningDate.toLowerCase().includes(filterBoxesInputs[6].toLowerCase());
        });
    }
    // --------------- filtering the currentAddress
    if (filterBoxesInputs[7].length != 0) {
        data = data.filter(trainee => {
            return trainee.currentAddress.toLowerCase().includes(filterBoxesInputs[7].toLowerCase());
        });
    }
    // --------------- filtering the currentCompany
    if (filterBoxesInputs[8].length != 0) {
        data = data.filter(trainee => {
            return trainee.currentCompany.toLowerCase().includes(filterBoxesInputs[8].toLowerCase());
        });
    }
    // --------------- filtering the dateOfBirth
    if (filterBoxesInputs[9].length != 0) {
        data = data.filter(trainee => {
            return trainee.dateOfBirth.toLowerCase().includes(filterBoxesInputs[9].toLowerCase());
        });
    }
    //console.log("fetched data: " + JSON.stringify(data));
    return data;
}


// ----------------------- toggeling class to nav bar items, based on the selected row
function ToggleNavMenuBtns() {
    //  if the last row is selected then the add button will be enabled and edit/delete will be disabled
    let allRows = document.querySelectorAll('#traineeDataTable tbody tr');
    if (currentSelectedRow == allRows.length - 1) {
        document.getElementById('newBtn').classList.remove('disableBtn');
        document.getElementById('newBtn').classList.add('activeBtn');
        document.getElementById('editBtn').classList.remove('activeBtn');
        document.getElementById('editBtn').classList.add('disableBtn');
        document.getElementById('deleteBtn').classList.remove('activeBtn');
        document.getElementById('deleteBtn').classList.add('disableBtn');
    }
    // else if other rows are selected then add button will be disabled and edit/delete button will be enabled
    else {
        document.getElementById('newBtn').classList.remove('activeBtn');
        document.getElementById('newBtn').classList.add('disableBtn');
        document.getElementById('editBtn').classList.remove('disableBtn');
        document.getElementById('editBtn').classList.add('activeBtn');
        document.getElementById('deleteBtn').classList.remove('disableBtn');
        document.getElementById('deleteBtn').classList.add('activeBtn');
    }
}

// --------------------- handling filter-box clear btn, show hide functionality 
for (let inputBox = 0; inputBox < allFilterBox.length; inputBox++) {
    allFilterBox[inputBox].addEventListener('input', () => {
        let value = allFilterBox[inputBox].value;
        if (value.length == 0) {
            document.querySelectorAll('.close_btn')[inputBox].classList.add('noDisplay');
        } else {
            document.querySelectorAll('.close_btn')[inputBox].classList.remove('noDisplay');
        }
        // ----- applying filtered data 
        filterBoxesInputs[inputBox] = value;
        // ----- rendering the filtered data
        RenderRowData(SortData(findFilters(allRowsData)));
    });
}

// --------------------- handling filter-box clear btn, clear functionality
for (let btnNumber = 0; btnNumber < allFilterClearBtn.length; btnNumber++) {
    allFilterClearBtn[btnNumber].addEventListener('click', () => {
        document.querySelectorAll('.textSearchBox')[btnNumber].value = "";
        document.querySelectorAll('.close_btn')[btnNumber].style.display = 'none';
        filterBoxesInputs[btnNumber] = "";
        RenderRowData(SortData(findFilters(allRowsData)));
    })
}

// --------------------- clearing all the filters when clear filter is clicked
document.querySelector('#clearAllFilters').addEventListener('click', () => {
    // ----- clearing all filter boxes
    for (let boxNumber = 0; boxNumber < allFilterBox.length; boxNumber++) {
        // ----- clearing the filterbox
        allFilterBox[boxNumber].value = "";
        // ----- clearing the filterBoxesInputs variable
        filterBoxesInputs[boxNumber] = "";
    }
    // ----- hidding all filter clear btns of table
    for (let filterClearBtnNumber = 0; filterClearBtnNumber < allFilterClearBtn.length; filterClearBtnNumber++) {
        allFilterClearBtn[filterClearBtnNumber].classList.add('noDisplay');
    }
    RenderRowData(allRowsData);
});


// --------------------- toggling the ascending and descending orders i of all columns 
let sortingButtons = document.querySelectorAll('#traineeDataTable thead tr th i'); // all ascending or descending icons 
for (let elemNumber = 0; elemNumber < sortingButtons.length; elemNumber++) {
    sortingButtons[elemNumber].addEventListener('click', function () {
        let parentElement = this.parentNode.parentElement;
        let index = Array.prototype.indexOf.call(parentElement.children, this.parentNode);

        if (sortingOrder[index - 1] == undefined || sortingOrder[index - 1] == true) {
            sortingOrder[index - 1] = false;
        }
        else {
            sortingOrder[index - 1] = true;
        }
        RenderRowData(SortData(findFilters(allRowsData)));
        let allI = this.parentNode.querySelectorAll('i');
        for (let i of allI) {
            if (i.classList.contains('sortAscending')) {
                i.classList.remove('sortAscending');
                i.classList.add('sortDescending');
            } else {
                i.classList.remove('sortDescending');
                i.classList.add('sortAscending');
            }
        }
    })
}

// ----------- function for closing the popup model
function ClosePopUpModel() {
    document.getElementById("modalContainer").style.display = 'none';
}