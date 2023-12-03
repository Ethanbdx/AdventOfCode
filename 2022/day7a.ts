import { readFileSync } from "fs";

interface Directory {
  size: number;
  children: string[];
}

interface DirectoryMap {
  [path: string]: Directory;
}

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

const values = Object.keys(directories)
  .filter((x) => directories[x].size <= 100_000)
  .map((x) => {
    return { label: x, ...directories[x] };
  })
  .reduce((sum, x) => sum + x.size, 0);

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
