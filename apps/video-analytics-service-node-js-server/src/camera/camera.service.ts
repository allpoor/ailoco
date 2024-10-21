import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { CameraServiceBase } from "./base/camera.service.base";

@Injectable()
export class CameraService extends CameraServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
