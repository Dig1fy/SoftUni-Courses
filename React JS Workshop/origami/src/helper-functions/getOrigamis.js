
// const getOrigamis = async () => {
//     fetch('http://localhost:9999/api/origami')
//         .then(x => x.json())
//         .catch(err => console.log(err))
//     // this.setState({ origamis: origamis })
// }

  
const getOrigamis = async (length) => {
    const promise = await fetch(`http://localhost:9999/api/origami?length=${length}`)
    const origamis = await promise.json()
    return origamis
  }

export default getOrigamis