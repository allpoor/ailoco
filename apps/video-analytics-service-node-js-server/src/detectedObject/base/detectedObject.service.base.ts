/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { PrismaService } from "../../prisma/prisma.service";
import { Prisma, DetectedObject as PrismaDetectedObject } from "@prisma/client";

export class DetectedObjectServiceBase {
  constructor(protected readonly prisma: PrismaService) {}

  async count(
    args: Omit<Prisma.DetectedObjectCountArgs, "select">
  ): Promise<number> {
    return this.prisma.detectedObject.count(args);
  }

  async detectedObjects(
    args: Prisma.DetectedObjectFindManyArgs
  ): Promise<PrismaDetectedObject[]> {
    return this.prisma.detectedObject.findMany(args);
  }
  async detectedObject(
    args: Prisma.DetectedObjectFindUniqueArgs
  ): Promise<PrismaDetectedObject | null> {
    return this.prisma.detectedObject.findUnique(args);
  }
  async createDetectedObject(
    args: Prisma.DetectedObjectCreateArgs
  ): Promise<PrismaDetectedObject> {
    return this.prisma.detectedObject.create(args);
  }
  async updateDetectedObject(
    args: Prisma.DetectedObjectUpdateArgs
  ): Promise<PrismaDetectedObject> {
    return this.prisma.detectedObject.update(args);
  }
  async deleteDetectedObject(
    args: Prisma.DetectedObjectDeleteArgs
  ): Promise<PrismaDetectedObject> {
    return this.prisma.detectedObject.delete(args);
  }
}
