import { Button } from "@nextui-org/react";
import type { ButtonProps } from "@nextui-org/react";

type ReusableButtonPropsT = ButtonProps & {
    onClick: () => void;
    children: React.ReactNode;
};

export default function ResuableButton({
    onClick,
    children,
    ...rest
}: ReusableButtonPropsT) {
    return (
        <Button { ...rest } style={{ color: "black" }} onClick={onClick}>
            {children}
        </Button>
    );
}
