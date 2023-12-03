import { readFileSync } from "fs";

interface Directory {
  size: number;
  children: string[];
}

interface DirectoryMap {
  [path: string]: Directory;
}

const totalSpace = 70000000;
const neededSpace = 30000000;

const directories: DirectoryMap = {};

const input = readFileSync("day7.txt", { encoding: "utf8" }).split("\r\n");

const path = [];
let i = 0;
while (i < input.length) {
  if (input[i] === "$ cd ..") {
    path.pop();
  }

  if (input[i].includes("$ ls")) {
    const [, label] = input[i - 1].split("$ cd ");
    path.push(label);
    const dirKey = path.join("");
    directories[dirKey] = { size: 0, children: [] };
  }

  if (!input[i].includes("$")) {
    const dirKey = path.join("");
    if (input[i].includes("dir")) {
      const childKey = dirKey + input[i].split("dir ")[1];
      directories[dirKey].children.push(childKey);
    } else {
      directories[dirKey].size += parseInt(input[i].split(" ")[0]);
    }
  }

  i++;
}

Object.keys(directories).forEach((x) => {
  directories[x].size += addChildren(x);
});

const unusedSpace = totalSpace - directories["/"].size;
const spaceToFree = neededSpace - unusedSpace;

console.log(unusedSpace);
console.log(spaceToFree);

const values = Object.values(directories)
  .filter((x) => x.size >= spaceToFree)
  .sort((x, y) => x.size - y.size);

console.log(values);

function addChildren(key: string): number {
  let sum = 0;
  const stack = [...directories[key].children];
  while (stack.length > 0) {
    const dirKey = stack.shift();
    sum += directories[dirKey].size;
    stack.push(...directories[dirKey].children);
  }

  return sum;
}
