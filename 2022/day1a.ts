import { readFileSync as read } from 'fs';

let max = 0;
let runningTotal = 0;

read("day1.txt", { encoding: 'utf8' })
    .split('\r\n')
    .forEach(x => {
        if (x.length > 0) {
            const number = parseInt(x);
            runningTotal += number;
        } else {
            if (runningTotal > max) {
                max = runningTotal;
            }

            runningTotal = 0;
        }
    });

console.log(max)