import { Button } from "@nextui-org/react";
import type { ButtonProps } from "@nextui-org/react";

type ReusableButtonPropsT = ButtonProps & {
    onPress: () => void;
    children: React.ReactNode;
};

const reusableButtonStyle = {
    fontFamily: "Rasa",
    fontWeight: 600,
    fontSize: "18px",
    lineHeight: "40.8px",
    color: "#404040",
};

export default function ResuableButton({
    onPress,
    children,
    ...rest
}: ReusableButtonPropsT) {
    return (
        <Button {...rest} style={reusableButtonStyle} onPress={onPress}>
            {children}
        </Button>
    );
}
