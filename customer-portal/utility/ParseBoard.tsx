export default function ParseBoard(boardObj:Array<any> ) {
  let commitArray:Array<any> = []
  for (let i = 0; i < boardObj.length; i++ ) {
    if (boardObj[i].attachments.length > 0) {
      for (let j = 0; j < boardObj[i].attachments.length; j++ ) {
        commitArray.push(boardObj[i].attachments[j].name)
      }
    } 
  }
  return commitArray
}