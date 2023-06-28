import Link from 'next/link'
import { Container, Navbar, Text, Grid, Col, Button } from '@nextui-org/react'

export default function Home() {
  return (
    <Container>
      <Navbar isCompact variant={'static'}>
        <Navbar.Brand>
          <Text b color="inherit">
            Partner Dashboard
          </Text>
        </Navbar.Brand>
        <Navbar.Content>
          <Navbar.Link href="/api/auth/signin">Sign In</Navbar.Link>
        </Navbar.Content>
      </Navbar>
      <Grid.Container justify="center" css={{"height": "700px", "backgroundImage": "url()"}}>
        <Grid xs={12} sm={6} alignItems="center">
          <Col css={{"width": "100%"}}>
            <Text weight={"bold"} size={65} css={{"textAlign": "center"}}>Partner Dashboard</Text>
            <Text weight={"bold"} size={30} css={{"textAlign": "center"}}>For your Current and Future Projects</Text>
            <Button as={Link} href="/api/auth/signin" size="md" shadow color="primary" auto ghost css={{"width": "100%", "marginTop": "10px"}}>Sign In to View Projects</Button>
          </Col>
        </Grid>
      </Grid.Container>
    </Container>   
  )
}
