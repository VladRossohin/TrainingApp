export class Exercise {
    constructor (
        public id?: number,
        public trainingId?: number,
        public sensorId?: number,
        public startDateTime?: Date,
        public endDateTime?: Date
    ) {}
}