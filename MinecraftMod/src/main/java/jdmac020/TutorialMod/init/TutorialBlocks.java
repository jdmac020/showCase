package jdmac020.TutorialMod.init;

import jdmac020.TutorialMod.init.blocks.BlockCopper;
import jdmac020.TutorialMod.init.blocks.BlockRuby;
import jdmac020.TutorialMod.init.blocks.ores.CopperOre;
import jdmac020.TutorialMod.init.blocks.ores.RubyOre;
import net.minecraft.block.Block;
import net.minecraft.block.material.Material;
import net.minecraft.client.Minecraft;
import net.minecraft.client.renderer.block.model.ModelResourceLocation;
import net.minecraft.item.Item;
import net.minecraft.item.ItemBlock;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class TutorialBlocks 
{
	//Ores
	public static Block RUBY_ORE;
	public static Block COPPER_ORE;
	
	//Blocks
	public static Block COPPER_BLOCK;
	public static Block RUBY_BLOCK;
	
	public static void init()
	{
		//Ore
		RUBY_ORE = new RubyOre();
		COPPER_ORE = new CopperOre();
		
		//Blocks
		COPPER_BLOCK = new BlockCopper();
		RUBY_BLOCK = new BlockRuby();
	}
	
	public static void register()
	{
		registerBlock(RUBY_ORE);
		registerBlock(COPPER_ORE);
		registerBlock(COPPER_BLOCK);
		registerBlock(RUBY_BLOCK);
	}
	
	public static void registerBlock(Block block)
	{
		GameRegistry.register(block);
		ItemBlock item = new ItemBlock(block);
		item.setRegistryName(block.getRegistryName());
		GameRegistry.register(item);
	}
	
	public static void registerRenders()
	{
		registerRender(RUBY_ORE);
		registerRender(COPPER_ORE);
		registerRender(COPPER_BLOCK);
		registerRender(RUBY_BLOCK);
	}
	
	public static void registerRender(Block block)
	{
		Minecraft.getMinecraft().getRenderItem().getItemModelMesher()
		.register(Item.getItemFromBlock(block), 0, new ModelResourceLocation(block.getRegistryName(), "inventory"));
	}
}
