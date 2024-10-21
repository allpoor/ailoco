import { TextDetection as TTextDetection } from "../api/textDetection/TextDetection";

export const TEXTDETECTION_TITLE_FIELD = "id";

export const TextDetectionTitle = (record: TTextDetection): string => {
  return record.id?.toString() || String(record.id);
};
