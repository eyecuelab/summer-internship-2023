async function Details () {
  const res = await fetch (
    'https://thisWouldBeOurAPI.test.com/posts/${params.id}',
    { cache: 'no-store'}
  );
  const data = await res.json()

  return (
    <div>
      {data.testBody}
    </div>
  )
}