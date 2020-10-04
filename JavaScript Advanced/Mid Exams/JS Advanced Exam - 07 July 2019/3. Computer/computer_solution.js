class Computer {

    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory = hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
    }

    installAProgram(name, requiredSpace) {
        if (this.hddMemory < requiredSpace) {
            throw new Error('There is not enough space on the hard drive');
        }

        let newObj = { name: name, requiredSpace: requiredSpace };
        this.installedPrograms.push(newObj);
        this.hddMemory = Number(this.hddMemory) - Number(requiredSpace);

        return newObj;
    }

    uninstallAProgram(name) {
        let desiredProgram = this.installedPrograms.filter(x => x.name === name)[0];

        if (!desiredProgram) {
            throw new Error('Control panel is not responding');
        }

        this.hddMemory = Number(this.hddMemory) + Number(desiredProgram.requiredSpace);
        let index = this.installedPrograms.indexOf(desiredProgram, 0);
        this.installedPrograms.splice(index, 1);

        return this.installedPrograms;
    }

    openAProgram(name) {
        let desiredProgram = this.installedPrograms.filter(x => x.name === name)[0];
        let openedProgram = this.taskManager.find(p => p.name === name);

        if (!desiredProgram) {
            throw new Error(`The ${name} is not recognized`);
        }
        if (openedProgram) {
            throw new Error(`The ${name} is already open`);
        }

        let neededRAM = (desiredProgram.requiredSpace / this.ramMemory) * 1.5;
        let neededCPU = ((desiredProgram.requiredSpace / this.cpuGHz) / 500) * 1.5;

        let totalRamUsage = this.taskManager.reduce((ac, current) => ac + current.ramUsage, 0) + neededRAM;
        let totalCPU = this.taskManager.reduce((ac, current) => ac + current.cpuUsage, 0) + neededCPU;

        if (totalRamUsage >= 100) {
            throw new Error(`${name} caused out of memory exception`)
        } else if (totalCPU >= 100) {
            throw new Error(`${name} caused out of cpu exception`)
        }

        let newProgramObj = {
            name: name,
            ramUsage: neededRAM,
            cpuUsage: neededCPU
        }

        this.taskManager.push(newProgramObj);
        return newProgramObj;
    }

    taskManagerView() {
        let isThereOpenedProgram = this.taskManager.length > 0;

        if (!isThereOpenedProgram) {
            return 'All running smooth so far';
        }

        let result = '';

        for (const program of this.taskManager) {
            result += `Name - ${program.name} | Usage - CPU: ${(program.cpuUsage).toFixed(0)}%, RAM: ${(program.ramUsage).toFixed(0)}%\n`
        }

        return result.trim();
    }
}

//example of unit test  (arrange + act)
// let computer = new Computer(4096, 7.5, 250000);

// computer.installAProgram('Word', 7300);
// computer.installAProgram('Excel', 10240);
// computer.installAProgram('PowerPoint', 12288);
// computer.installAProgram('Solitare', 1500);

// computer.openAProgram('Word');
// computer.openAProgram('Excel');
// computer.openAProgram('PowerPoint');
// computer.openAProgram('Solitare');

// let actualResult = computer.taskManagerView();
// let expectedResult = `Name - Word | Usage - CPU: 3%, RAM: 3%
// Name - Excel | Usage - CPU: 4%, RAM: 4%
// Name - PowerPoint | Usage - CPU: 5%, RAM: 5%
// Name - Solitare | Usage - CPU: 1%, RAM: 1%`;