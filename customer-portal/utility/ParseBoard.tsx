export default function ParseBoard(boardObj:Array<any> ) {
  let commitArray:Array<String> = []
  for (let i = 0; i< boardObj.length; i++ ) {
    if (boardObj[i].attachments.length > 0) {
      commitArray += boardObj[i].attachments.name
    } else {
      
    }
  }
}