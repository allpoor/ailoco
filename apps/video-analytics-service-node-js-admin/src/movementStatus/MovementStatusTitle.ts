import { MovementStatus as TMovementStatus } from "../api/movementStatus/MovementStatus";

export const MOVEMENTSTATUS_TITLE_FIELD = "id";

export const MovementStatusTitle = (record: TMovementStatus): string => {
  return record.id?.toString() || String(record.id);
};
