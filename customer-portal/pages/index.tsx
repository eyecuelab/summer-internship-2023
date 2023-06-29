import Link from "next/link";
import { Container, Navbar, Text, Grid, Col, Image } from "@nextui-org/react";

export default function Home() {
  return (
    <Container>
      <Navbar isCompact variant={"static"}>
        <Navbar.Brand>
          <Text b color="inherit">
            Partner Dashboard
          </Text>
        </Navbar.Brand>
        <Navbar.Content>
          <Navbar.Link href="/api/auth/signin">Sign In</Navbar.Link>
        </Navbar.Content>
      </Navbar>
      <Grid.Container
        justify="center"
        css={{ height: "700px", backgroundImage: "url()" }}
      >
        <Grid xs={12} sm={6} alignItems="center">
          <Col css={{ width: "100%" }}>
            <Text weight={"bold"} size={65} css={{ textAlign: "center" }}>
              Partner Dashboard
            </Text>
            <Text weight={"bold"} size={30} css={{ textAlign: "center" }}>
              For your Current and Future Projects
            </Text>
            <Text size={20} css={{ textAlign: "center" }}>
              Sign in to get started
            </Text>
            <Image
              width={420}
              height={480}
              src="/content-moderation.gif"
              alt="Default Image"
              objectFit="cover"
            />
          </Col>
        </Grid>
      </Grid.Container>
    </Container>
  );
}
