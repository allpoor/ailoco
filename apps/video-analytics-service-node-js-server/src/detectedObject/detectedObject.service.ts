import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { DetectedObjectServiceBase } from "./base/detectedObject.service.base";

@Injectable()
export class DetectedObjectService extends DetectedObjectServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
