import { readFileSync } from "fs";
import { determineScore } from "./day2a";
// A | X = ROCK
// B | Y = PAPER
// C | Z = SCISSORS

// Y = NEED DRAW
// X = NEED LOSE
// Z = NEED WIN

const tieMap = {
    "A" : "X",
    "B" : "Y",
    "C" : "Z"
}

const winMap = {
    "A" : "Y",
    "B" : "Z",
    "C" : "X"
}

const loseMap = {
    "A" : "Z",
    "B" : "X",
    "C" : "Y"
}

let runningScore = 0;

readFileSync("day2.txt", {encoding: 'utf8'}).split('\r\n').forEach(x => {
    const [theirShape, desiredOutcome] = x.split(' ');
    const ourShape = decideMove(theirShape, desiredOutcome);
    const roundScore = determineScore(theirShape, ourShape);
    runningScore += roundScore;
})

console.log(runningScore);

function decideMove(thierShape: string, desiredOutcome: string): string {
    if(desiredOutcome === 'Y') {
        return tieMap[thierShape];
    }

    if(desiredOutcome === 'X') {
        return loseMap[thierShape];
    }

    if(desiredOutcome === "Z") {
        return winMap[thierShape];
    }

    throw "Agrument out of bounds"
}
