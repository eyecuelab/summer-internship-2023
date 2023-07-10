import React from "react";
import Document, {
    Html,
    Head,
    Main,
    NextScript,
    DocumentContext,
} from "next/document";
import { CssBaseline } from "@nextui-org/react";

class MyDocument extends Document {
    static async getInitialProps(ctx: DocumentContext) {
        const initialProps = await Document.getInitialProps(ctx);
        return {
            ...initialProps,
            styles: React.Children.toArray([initialProps.styles]),
        };
    }

    render() {
        return (
            <Html lang="en">
                <Head>{CssBaseline.flush()} 
                <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Rasa&display=swap" rel="stylesheet"></link>
                </Head>
                <body>
                    <Main />
                    <NextScript />
                </body>
            </Html>
        );
    }
}

export default MyDocument;
