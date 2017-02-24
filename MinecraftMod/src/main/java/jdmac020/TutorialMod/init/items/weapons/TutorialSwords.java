package jdmac020.TutorialMod.init.items.weapons;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.item.Item.ToolMaterial;
import net.minecraft.item.ItemSword;

public class TutorialSwords extends ItemSword
{

	public TutorialSwords(ToolMaterial material, String name) 
	{
		super(material);
		setUnlocalizedName(name);
		setRegistryName(name);
		setCreativeTab(TutorialTabs.tabTutorialWeapons);
	}

}
