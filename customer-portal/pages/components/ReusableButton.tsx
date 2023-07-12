import { Button } from "@nextui-org/react";
import type { ButtonProps } from "@nextui-org/react";

type ReusableButtonPropsT = ButtonProps & {
    onPress: () => void;
    children: React.ReactNode;
};

export default function ResuableButton({
    onPress,
    children,
    ...rest
}: ReusableButtonPropsT) {
    return (
        <Button {...rest} style={{ color: "black" }} onPress={onPress}>
            {children}
        </Button>
    );
}
