import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { MovementStatusServiceBase } from "./base/movementStatus.service.base";

@Injectable()
export class MovementStatusService extends MovementStatusServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
