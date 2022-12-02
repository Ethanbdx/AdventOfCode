import { readFileSync } from "fs";
// A | X = ROCK
// B | Y = PAPER
// C | Z = SCISSORS

let runningScore = 0;

readFileSync("day2.txt", {encoding: 'utf8'}).split('\r\n').forEach(x => {
    const [theirShape, ourShape] = x.split(' ');
    const roundScore = determineScore(theirShape, ourShape);
    runningScore += roundScore;
})

console.log(runningScore);

export function determineScore(theirShape: string, ourShape: string) {
    console.log("OUR SHAPE:", ourShape)
    console.log("THEIR SHAPE:", theirShape)

    let score = 0;

    //Score from our shape
    switch(ourShape) {
        case 'X': {
            ourShape = 'A';
            score += 1;
            break;
        }
        case 'Y': {
            ourShape = 'B';
            score += 2;
            break;
        }
        case 'Z': {
            ourShape = 'C';
            score += 3
            break;
        }
    }

    console.log("OUR TRANSLATED SHAPE:", ourShape)

    //Tie Case
    if(ourShape == theirShape) {
        score += 3;
    }

    //Our Win Case
    if((theirShape === 'A' && ourShape == 'B') || (theirShape === 'B' && ourShape === 'C') || (theirShape === 'C' && ourShape === 'A')) {
        score += 6;
    } 

    return score;
}