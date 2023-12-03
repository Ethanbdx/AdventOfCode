import { readFileSync as read } from 'fs';

const calorieTotals: number[] = []

let runningTotal = 0;
read("day1.txt", { encoding: 'utf8' })
    .split('\r\n')
    .forEach(x => {
        if (x.length > 0) {
            const number = parseInt(x);
            runningTotal += number;
        } else {
            calorieTotals.push(runningTotal);

            runningTotal = 0;
        }
    });

const top3ElvesSum = calorieTotals
    .sort((a, b) => b - a)
    .slice(0, 3)
    .reduce((a, b) => a + b);

console.log(top3ElvesSum);