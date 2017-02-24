package jdmac020.TutorialMod.init.worldgen;

import java.util.Random;

import jdmac020.TutorialMod.init.TutorialBlocks;
import net.minecraft.util.math.BlockPos;
import net.minecraft.world.World;
import net.minecraft.world.chunk.IChunkGenerator;
import net.minecraft.world.chunk.IChunkProvider;
import net.minecraft.world.gen.feature.WorldGenerator;
import net.minecraftforge.fml.common.IWorldGenerator;

public class TutorialWorldGen implements IWorldGenerator
{
	//OverWorldOres
	private WorldGenerator RUBY_ORE;
	private WorldGenerator COPPER_ORE;
	
	public TutorialWorldGen()
	{
		this.RUBY_ORE = new TutorialWorldGenMineable(TutorialBlocks.RUBY_ORE.getDefaultState(), 6);
		this.COPPER_ORE = new TutorialWorldGenMineable(TutorialBlocks.COPPER_ORE.getDefaultState(), 8);
	}

	@Override
	public void generate(Random random, int chunkX, int chunkZ, World world, IChunkGenerator chunkGenerator,
			IChunkProvider chunkProvider) 
	{
		switch(world.provider.getDimension())
		{
		case 0:  //OverWorld
			
			this.runGenerator(this.RUBY_ORE, world, random, chunkX, chunkZ, 45, 0, 35);
			this.runGenerator(this.COPPER_ORE, world, random, chunkX, chunkZ, 65, 20, 65);
			
			break;
			
		case -1:  //Nether
			
			break;
			
		case 1:  //End
			
			break;
		}
	}
	
	private void runGenerator(WorldGenerator generator, World world, Random random, int chunkX, int chunkZ, int ChanceToSpawn, int minHeight, int maxHeight)
	{
		if(minHeight < 0 || maxHeight > 256 || minHeight > maxHeight)
			throw new IllegalArgumentException("Minimum or Maximum Height out of bounds");
		
		int heightDiff = maxHeight - minHeight +1;
		
		for(int i = 0; i < ChanceToSpawn; i++)
		{
			int x = chunkX * 16 + random.nextInt(16);
			int y = minHeight + random.nextInt(heightDiff);
			int z = chunkZ * 16 + random.nextInt(16);
			
			generator.generate(world, random, new BlockPos(x, y, z));
		}
	}
	
}
