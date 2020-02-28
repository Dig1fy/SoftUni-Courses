class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username || !salary || !position || !department || salary < 0) {
            throw new Error('Invalid input!')
        }

        let findDepartment = this.departments.find(x => x.depName === department);

        let newEmployee = {
            username: username,
            salary: salary,
            position: position
        }

        if (!findDepartment) {
            let newDep = {
                depName: department,
                employees: [],
                averageSalary: function () {
                    return this.employees.reduce((a, b) => a + b.salary, 0) / this.employees.length;
                }
            }
            this.departments.push(newDep);
            newDep.employees.push(newEmployee);

        } else {
            findDepartment.employees.push(newEmployee);
        }

        return `New employee is hired. Name: ${newEmployee.username}. Position: ${newEmployee.position}`
    }

    bestDepartment() {
        let [currrentlyBestDep] = [...this.departments].sort((a, b) => b.averageSalary - a.averageSalary);

        let result = `Best Department is: ${currrentlyBestDep.depName}\n`;
        result += `Average salary: ${currrentlyBestDep.averageSalary().toFixed(2)}\n`;
        result += [...currrentlyBestDep.employees]
            .sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username))
            .map(e => `${e.username} ${e.salary} ${e.position}`)
            .join('\n');

        return result;
    }
}

// let c = new Company();
// c.addEmployee("Stanimir", 2000, "engineer", "Construction");
// console.log(c.addEmployee("Stanimir", 2000, "engineer", "Human resources"));
// c.addEmployee("Slavi", 500, "dyer", "Construction");
// c.addEmployee("Stan", 2000, "architect", "Construction");
// c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
// c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");
// console.log(c.bestDepartment());