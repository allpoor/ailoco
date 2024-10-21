import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { TextDetectionServiceBase } from "./base/textDetection.service.base";

@Injectable()
export class TextDetectionService extends TextDetectionServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
