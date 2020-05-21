export class Kick {
    constructor (
        public id?: number,
        public exerciseId?: number,
        public kickDateTime?: Date,
        public kickPower?: number,
        public reactionSpeed?: number,
        public kickAccuracy?: number  
    ) {}
}