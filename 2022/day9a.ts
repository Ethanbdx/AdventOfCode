import { readFileSync } from "fs";

// const directions = ["R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2"];

const directions = readFileSync("day9.txt", { encoding: "utf8" }).split("\r\n");

const headPos = [0, 0];
const tailPos = [0, 0];
const set = new Set();
set.add(tailPos.join(","));

directions.forEach((x) => {
  updateHeadPos(x);
});

console.log(set.size);

function updateHeadPos(instruction: string) {
  const [direction, length] = instruction.split(" ");
  for (let i = 0; i < parseInt(length); i++) {
    switch (direction) {
      case "U":
        headPos[0] += 1;
        break;
      case "D":
        headPos[0] -= 1;
        break;
      case "L":
        headPos[1] -= 1;
        break;
      case "R":
        headPos[1] += 1;0
        break;
    }

    const distance = Math.sqrt(
      Math.pow(headPos[1] - tailPos[1], 2) +
        Math.pow(headPos[0] - tailPos[0], 2)
    );

    if (distance >= 2) {
      updateTailPos(direction);

      const tail = tailPos.join(",");
      if (!set.has(tail)) {
        set.add(tail);
      }
    }
  }
}

function updateTailPos(direction: string) {
  switch (direction) {
    case "U":
      tailPos[0] = headPos[0] - 1;
      tailPos[1] = headPos[1];
      break;
    case "D":
      tailPos[0] = headPos[0] + 1;
      tailPos[1] = headPos[1];
      break;
    case "L":
      tailPos[1] = headPos[1] + 1;
      tailPos[0] = headPos[0];
      break;
    case "R":
      tailPos[1] = headPos[1] - 1;
      tailPos[0] = headPos[0];
      break;
  }
}
