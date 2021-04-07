const getOrigamis = async (length) => {
    const promise = await fetch(`http://localhost:9999/api/origami?length=${+length || 20}`)
    const origamis = await promise.json()
    return origamis
  }

export default getOrigamis  