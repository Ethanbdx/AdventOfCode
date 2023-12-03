import { readFileSync } from "fs";

export const messageInput = readFileSync("day6.txt", { encoding: "utf8" });

console.log(findMarkerPosition(messageInput, 4));

export function findMarkerPosition(input: string, windowSize: number): number {
  let i = 0;
  while (i < input.length) {
    let window = input.slice(i, windowSize + i);
    if (allCharactersUnique(window)) {
      return i + windowSize;
    }
    i++;
  }
}

function allCharactersUnique(input: string): boolean {
  console.log(input);
  const set = new Set();
  for (let i = 0; i < input.length; i++) {
    if (set.has(input[i])) {
      return false;
    }

    set.add(input[i]);
  }

  return true;
}
